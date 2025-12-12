13
3728031612929
404923780867425 1761863303310530000
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -14.4034690856933594,
    "Y": -9.1069450378417969
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404920991244555:1761863302660545600",
  "next_sibling": "404929145737271:1761863304560550700",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404923781127317:1761863303310589900",
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
  "aoid": "404923781239203:1761863303310616000",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404923781127317:1761863303310589900",
    "DefaultRenderer": "404923781290029:1761863303310627800",
    "DepletedRenderer": "404923781271926:1761863303310623700"
  }
},
{
  "cid": 5,
  "aoid": "404923781252447:1761863303310619000",
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
