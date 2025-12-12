13
3341484556289
404862478590829 1761863289027036300
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -11.3248653411865234,
    "Y": 9.4502363204956055
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404860833395539:1761863288643704300",
  "next_sibling": "404864195409122:1761863289427056600",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404862478889077:1761863289027104900",
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
  "aoid": "404862479009563:1761863289027133000",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404862478889077:1761863289027104900",
    "DefaultRenderer": "404862479063872:1761863289027145700",
    "DepletedRenderer": "404862479048134:1761863289027142100"
  }
},
{
  "cid": 5,
  "aoid": "404862479024957:1761863289027136800",
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
