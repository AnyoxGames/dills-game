13
3362959392769
404864195409122 1761863289427056600
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -12.8641710281372070,
    "Y": 9.0440311431884766
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404862478590829:1761863289027036300",
  "next_sibling": "404866269705368:1761863289910369600",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404864195637022:1761863289427109000",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404864195748263:1761863289427134900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404864195637022:1761863289427109000",
    "DefaultRenderer": "404864195796939:1761863289427146300",
    "DepletedRenderer": "404864195781373:1761863289427142600"
  }
},
{
  "cid": 5,
  "aoid": "404864195761421:1761863289427138000",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
