13
3706556776449
404920991244555 1761863302660545600
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -16.5413932800292969,
    "Y": -8.3372917175292969
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404916484712219:1761863301610518400",
  "next_sibling": "404923780867425:1761863303310530000",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404920991551575:1761863302660615900",
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
  "aoid": "404920991683628:1761863302660646600",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404920991551575:1761863302660615900",
    "DefaultRenderer": "404920991743312:1761863302660660600",
    "DepletedRenderer": "404920991724177:1761863302660656200"
  }
},
{
  "cid": 5,
  "aoid": "404920991699538:1761863302660650300",
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
